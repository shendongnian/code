        public ActionResult GenerateExcel()
        {
            var generator = new ExcelWriter();
            var xml = this.Request.Form["grid_xml"];
            xml = this.Server.UrlDecode(xml);
            var xmlObj = XDocument.Parse(xml);
            foreach (var x in xmlObj.Descendants("columns").ElementAt(0).Descendants("column"))
            {
                var w = x.Attribute("width").Value;
                if (Convert.ToString(w).Equals("0")) { x.SetAttributeValue("hidden", "true"); }
            }
            xml = xmlObj.ToString();
            var stream = generator.Generate(xml);
            return File(stream.ToArray(), generator.ContentType, "grid.xlsx");
        }
