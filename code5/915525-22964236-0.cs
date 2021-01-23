           foreach (var hashtable in from item in offsets
                                                     let element = item.Substring(4,2)
                                                     let length = Convert.ToInt32(item.Substring(6, 6))
                                                     let position = item.Substring(7, 4)
                                                     select new Hashtable
                                                         {
                                                             {"Element", element},
                                                             {"Length", length},
                                                             {"Position", position}
                                                         })
