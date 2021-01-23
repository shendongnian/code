             // DataTable Instance...
            DataTable table = new DataTable();
            //Get all properties of contract list items
            var properties = contacts.GetType().GetProperties();
            // Remove contract list property
            properties = properties.ToList().GetRange(0, properties.Count() - 1).ToArray();
            // Add column as named by property name
            properties.ToList().ForEach(p => table.Columns.Add(p.Name,typeof(string)));
            // Add rows from contracts list
            contacts.ForEach(x =>  table.Rows.Add(x.Name,x.Phone));
