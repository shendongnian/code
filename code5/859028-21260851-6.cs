        //the conversion from STRING CONTAINING HEXADECIMAL CHARACTERS to INTEGER
        //can be done by standard methods included in basic interger...
        //YOUR'S doesn't work because you didn't remove the `u` in front of the HEX VALUE
        //in string - and i'm  also not sure about the implicit conversion between
        //hexadecimal string and integer....
        
        //so, the improved version of your code using the stuff you have now
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //this should work for values stored as integer
            data = (from query in XElement.Load("Data.xml").Descendants("ItemInfo")
                select new ItemInfo
                {
                    value = int.Parse(query.Element("Value").Value.ToString().Substring(1),NumberStyles.HexNumber),
                    name = query.Element("Name").Value
                }).ToList();
            int itemcount = data.length;
            while (itemcount-- > 0)
            {
                TextBlock t = new TextBlock()
                {
                    Width = 75,
                    Height = 75,
                    Text = @"\" + data[itemcount].value,
                    FontFamily = new FontFamily("Segoe UI Symbol")
                };
                wrapPanel.Children.Add(t);
        
            }
        }
