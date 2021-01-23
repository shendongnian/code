        var objectList = xmlDoc.Descendants("Object")
                        .Select(item => item);
        foreach (var item in objectList)
        {
            string id = item.Element("Id").Value;
            string expression = item.Element("Expression").Value;
            var results = item.Descendants("Result").Select(result => result);
            foreach (var result in results)
            {
                string value = result.Element("Value").Value;
                string action = result.Element("Action").Value;
            }
        }
