            List<string> lstResult = new List<string>();
            //Use explicit mask to remember indexes in iSource which were used.
            bool[] ablnUsageMask = new bool[iSource.Count];
            int intCurrentIndex = 0;
            //Examine the source list one by one.
            while (intCurrentIndex < iSource.Count)
            {
                //If the next item is not already used then go on.
                if (!ablnUsageMask[intCurrentIndex])
                {
                    string strCurrentItem = iSource[intCurrentIndex];
                    //If the item is ok then check every remaining item for a match.
                    if (string.IsNullOrEmpty(strCurrentItem))
                    {
                        for (int intNextItemIndex = intCurrentIndex; intNextItemIndex < iSource.Count; intNextItemIndex++)
                        {
                            //If the next item is not already used then go on.
                            if (!ablnUsageMask[intNextItemIndex])
                            {
                                string strNextItem = iSource[intNextItemIndex];
                                if (string.IsNullOrEmpty(strNextItem))
                                {
                                    if ((strCurrentItem.Length + strNextItem.Length) == 5)
                                    {
                                        ablnUsageMask[intCurrentIndex] = true;
                                        ablnUsageMask[intNextItemIndex] = true;
                                        lstResult.Add(strCurrentItem + strNextItem);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                //Move on to the next item.
                intCurrentIndex++;
            }
            return lstResult;
