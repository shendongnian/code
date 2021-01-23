            var items = LoadListings();//create a list of WordDef objects
            int i = 1;
            var sw = new StringBuilder();
            foreach(var myListing in items)
            {
               
                sw.AppendFormat("{0}", myListing.GetName() + "|");
                
                if (i=items.Count)
                {
                    sw.Replace("|", "", i,i);
                }else 
                { i++; }
            }
            //Console.WriteLine(myListing.GetName() + ": " + myListing.GetDefinition());
            Console.Write(sw);
