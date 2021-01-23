                public static void formatDecimalSeparator(ref string paramString)
                {
                    try
                    {
                        if (System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator == ",")
                        {
                            paramString = paramString.Replace(".", ",");
                        }
                        else
                        {
                            paramString = paramString.Replace(",", ".");
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
