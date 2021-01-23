    public ActionResult Export()
        {
            StringBuilder str = new StringBuilder();
            var tmp = db.Users.FirstOrDefault();     
            Type comp = tmp.GetType();                // get type
            foreach (PropertyInfo prop in comp.GetProperties())
            {
                str.Append(prop.Name + ",");          //set column names
            }
            str.Replace(",", "\n", str.Length - 1, 1);
            foreach (object item in db.Users)
            {
                foreach (PropertyInfo prop in item.GetType().GetProperties())
                {
                    try
                    {
                        string a = prop.GetValue(item, null).ToString();
                        str.Append(a + ",");
                    }
                    catch (NullReferenceException)
                    {
                        str.Append("null" + ",");           //for nulls, append string with "null"
                    }
                }
                str.Replace(",", "\n", str.Length - 1, 1);
            }
            string csv = str.ToString();
            return File(new System.Text.UTF8Encoding().GetBytes(csv), "text/csv", "Export.csv");
        }
