            using (var writer = new StreamWriter(@"C:\temp\yourfile.csv"))
            {
                string header = "DateModified,ModifiedBy,CustomerPricing,Id,Customer,Code";
                writer.WriteLine(header);
                foreach (var log in logs)
                {
                    string line = "\"" + log.DateModified.ToShortDateString() + "\",\"" + log.ModifiedBy + "\",\"" +
                                  // you don't have a CustomerPricing element, as the whole object is CustomerPricing
                                  // add a "Price" element and sub out the element value below
                                  //log.ChangedData.Element("CustomerPricing").Value + "\",\"" +
                                  log.ChangedData.Element("Id").Value + "\",\"" +
                                  log.ChangedData.Element("Customer").Value + "\",\"" +
                                  log.ChangedData.Element("Code").Value + "\"";
                    writer.WriteLine(line);
                }
            }
