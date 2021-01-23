                               IWebElement element = Driver.FindElement(By.XPath("Element XPath"));
                           }
                          catch (NoSuchElementException)
                            {
                              elementnotpresent=true;
                            }
                            if (elementnotpresent == true)
                            {
                                Console.WriteLine("Element not present");
                            }
                            else
                            {
                                throw new Exception("Element is present");
                            }
