    var ZipCodesAndCountryCodes = from line in File.ReadLines(fi.FullName)
                                  let country = line.Substring(1405,30)
                                  select new                            
                                  {
                                      ZipCode = line.Substring(1395, 5),
                                      CountryCode = (   string.IsNullOrWhiteSpace(country)
                                                     || country=="United States"
                                                     || country=="United States of America"
                                                     || country=="USA")
                                                     ? "US"
                                                     : country
                                  };
