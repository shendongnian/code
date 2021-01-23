            //Dependent function for Sorting
            //This Functions Retrieves the Database Field Name to be used by the
            // Orderby("Tag") function 
            // i.e. OrderBy(t => t.Area);
            // t = TrimTable
            // iSortCol = Column Number to Sort By
            Func<TrimTable, Int32, string> getColName =(
            (t, iSortCol) => iSortCol == 1 ? t.TAG :
                            iSortCol == 2 ? t.DESCRIPTION :
                            iSortCol == 3 ? t.SET_POINT :
                            iSortCol == 4 ? t.PRIORITY :
                            iSortCol == 5 ? t.LIMIT_TYPE :
                            iSortCol == 6 ? t.ALARM_TYPE :
                            iSortCol == 7 ? t.AUTOMATED_SYSTEM :
                            iSortCol == 8 ? t.COL_POL :
                            iSortCol == 9 ? t.PROPERTY :
                            iSortCol == 10 ? t.EQUIP_TYPE:
                            iSortCol == 11 ? t.P_ID :
                            iSortCol == 12 ? t.AREA :
                            iSortCol == 13 ? t.COMPLEX :
                            iSortCol == 14 ? t.UNIT :  //PI Unit Format Long-text
                            iSortCol == 15 ? t.UNIT_ : //Loop Number Format
                            iSortCol == 16 ? t.LOOP_TYPE : //Loop Type i.e. PI, FIT, PSV
                            iSortCol == 17 ? t.LOOP_ : //Loop Number
                            iSortCol == 18 ? t.LOOP_EXT  :
                            t.UNIT_
                );
            //Number of Columns to Sort
            int iSortCols = Convert.ToInt32(param.iSortingCols);
            Debug.WriteLine("Count of Sortable Columns" + iSortCols);
            //int	iSortCol_(int)	Column being sorted on (you will need to decode this number for your database)
            //string	sSortDir_(int)	Direction to be sorted - "desc" or "asc".
            //If Sort Expression Exists
            if (iSortCols > 0)
            {
                //Sorting
                string[] sSortDirection = new string[iSortCols]; // asc or desc
                Int32[] iSortColNum = new Int32[iSortCols]; //number
                //Get Sorting Parameters from MVC Controller
                for (int h = 0; h < iSortCols; h++)
                {
                    //Get Sort Direction
                    var s1 = "sSortDir_" + h;
                    sSortDirection[h] = Convert.ToString(Request[s1]);
                    //Get Sort Column Number
                    var s2 = "iSortCol_" + h;
                    iSortColNum[h] = Convert.ToInt32(Request[s2]);
                }
                //Build Orderby Statement
                for (int i = 0; i < iSortCols; i++)
                {
                    //If Current Column is Ascending/Descending
                    if (sSortDirection[i] == "asc")
                    {
                        //Orderby / Thenby
                        orderedTags = (i == 0) ? filteredTags.OrderBy(t => getColName(t, iSortColNum[i]))
                                                : orderedTags.ThenBy(t => getColName(t, iSortColNum[i]));
                    }
                    else
                    {
                        orderedTags = (i == 0) ? filteredTags.OrderByDescending(t => getColName(t, iSortColNum[i]))
                                               : orderedTags.ThenByDescending(t => getColName(t, iSortColNum[i]));
                    }
                }
                //Return Orderby LINQ to Original Result Variable
                filteredTags = orderedTags;
            }
            else
            {
                //Default Sort if None is Selected
                filteredTags = filteredTags.OrderBy(t => t.TAG);
            }
