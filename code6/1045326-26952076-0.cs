            string fileName = @"c:\temp\json\yourfile.json";
            string json;
            using (StreamReader sr = new StreamReader(fileName))
            {
                json = sr.ReadToEnd();
            }
            response myResponse = fastJSON.JSON.ToObject<response>(json);
            var item = myResponse.First(i => i.defindex == "5051");
            foreach (var price in item.prices)
            {
                foreach (var quality in price)
                {
                    Console.WriteLine("{0} {1}", quality.Tradable.Craftable[0].value, quality.Tradable.Craftable[0].currency);
                    keyprice = quality.Tradable.Craftable[0].value;
                    return keyprice;
                }
            }
