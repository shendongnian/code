                foreach (Section sec in report1.Sections)
                {
                    for (int i = 1; i < sec.ReportObjects.Count + 1; i++)
                    {
                        objMain = report1.Sections[sec.Name].ReportObjects[i];
                        try
                            {
                                FieldObject to1 = (FieldObject)objMain;
                                if(to1.Value == "A")
                                {                                
                                    to1.TextColor = ColorToUInt(Color.Red);
                                }
                                else
                                {
                                    to1.TextColor = ColorToUInt(Color.Blue);
                                }
                            }
                            catch (Exception){}
                    }                
                }
