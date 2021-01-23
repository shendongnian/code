      List<string> objcountries = new List<string>();
                CultureInfo[] objculture = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                foreach (CultureInfo getculture in objculture)
                {
                    RegionInfo objregion = new RegionInfo(getculture.LCID);
                    string ss = getculture.DisplayName;
                    if (!(objcountries.Contains(objregion.EnglishName)))
                    {
                        objcountries.Add(objregion.EnglishName);
                    }
                }
                objcountries.Sort();
                comboBox1.DataSource = objcountries;
