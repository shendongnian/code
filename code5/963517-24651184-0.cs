    private DataTable RoundScale(DataTable dtInput, int startingCol, int startingRow)
        {  
            int xOrder = 0;
            //write datatable values into a list (easier to work with)
            for (int j = startingRow; j < dtInput.Rows.Count; j++)
            {
                List<SortingData> numlist = new List<SortingData>();
                for (int iCol = startingCol; iCol < dtInput.Columns.Count; iCol++)
                {
                    if ((dtInput.Rows[j][iCol] != DBNull.Value) && (Convert.ToDouble(dtInput.Rows[j][iCol]) != 0))
                    {
                        SortingData LSO = new SortingData
                        {
                            NumberToBeRounded = Convert.ToDecimal(Math.Round((double)dtInput.Rows[j][iCol], 1)),
                            OrderNum = xOrder
                        };
                        numlist.Add(LSO);
                    }
                    else
                    {
                        SortingData LSO_1 = new SortingData
                        {
                            NumberToBeRounded = Convert.ToDecimal(0.0),
                            OrderNum = xOrder
                        };
                        numlist.Add(LSO_1);
                    }
                    xOrder++;
                }
                                
                //need to sort the list desc so unit is added to or removed from the largest item in the list first
                numlist = numlist.OrderByDescending(o => o.NumberToBeRounded).ToList();
                
                decimal numTotal = numlist.Sum(y => y.NumberToBeRounded);
                if (numTotal != 0)    //ignore if there are zero totals
                {
                    decimal diff = 100.0m - numTotal;
                    //the value should be only 1 decimal place
                    int update = Convert.ToInt32(diff / .1m);
                    if (update > 0)
                    {
                        for (int x = 0; x < update; x++)
                        {
                            var sortednumlist = numlist[x % numlist.Count()];
                            sortednumlist.NumberToBeRounded += .1m;                          
                        }
                    }
                    else
                    {
                        for (int x = 0; x < Math.Abs(update); x++)
                        {
                            var sortednumlist = numlist[x % numlist.Count()];
                            sortednumlist.NumberToBeRounded -= .1m;                           
                        }
                    }
                }
                //change order of list back to original order
                numlist = numlist.OrderBy(o => o.OrderNum).ToList();
                //now write the list back into that datatable row
                for (int i = startingCol; i < dtInput.Columns.Count; i++)
                {
                    var numlistout = numlist[i - startingCol];
                    dtInput.Rows[j][i] = numlistout.NumberToBeRounded;
                }
            }
            return dtInput;
        }
    public class SortingData
    {
    public decimal NumberToBeRounded { get; set; }
    public int OrderNum { get; set; }   
    }
