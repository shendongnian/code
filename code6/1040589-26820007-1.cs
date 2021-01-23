    var query = from gameScore in ParseObject.GetQuery("binInformation")
                        where gameScore.Get<string>("binLocation") == cbSelectArea.Text
                        select gameScore;
            IEnumerable<ParseObject> results = await query.FindAsync();
            foreach (var i in results)
            {
                var s = i.Get<int>("binMaxCapacity");
                
                tbMaxVolume.Text = s.ToString();
            }
