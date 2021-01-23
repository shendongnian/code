       public class MyBinaryTreePanel : Panel
        {
            public double MaxRowHeight { get; set; }
            public MyBinaryTreePanel()
            {
                MaxRowHeight = 0.0;
            }
            protected override Size ArrangeOverride(Size finalSize)
            {            
                double rowHeight=0;
                double columnWidth = finalSize.Width;
                int total = Children.Count;
                int temp = total;
               
                int count = 0;
                do
                {
                    temp /= 2;
                    count++;
                } while (temp != 1);
                count++;           
                int Row = count;   
                MaxRowHeight = finalSize.Height / total;
                
                double temrow = 0;
                int i = 0;
                for (int a = 0; a < Row; a++)
                {
                    double temp34 = 0;
                    double tempColumn = 0;                
                    
                    columnWidth = ((finalSize.Width) / (Math.Pow(2, a)));
                    for (int b = 0; b < (Math.Pow(2, a)); b++)
                    {
                        if (i < total)
                        {
                            rowHeight = Children[i].DesiredSize.Height > MaxRowHeight ? Children[i].DesiredSize.Height : MaxRowHeight;
                            Children[i].Arrange(new Rect( tempColumn,  temrow, columnWidth, rowHeight));
                            i++;
                            if (rowHeight >= temp34)
                            {
                                temp34 = rowHeight;
                            }
                            else
                            {
                                rowHeight = temp34;
                            }
                            tempColumn += columnWidth;
                        }
                       
                    }
                    temrow += temp34;
                    
                }//
                return finalSize;
            }
            protected override Size MeasureOverride(Size availableSize)
            {
                int total = Children.Count;
                int temp = total;
                int count = 0;
                do
                {
                    temp /= 2;
                    count++;
                } while (temp != 1);
                count++;
                int Row = count;
                MaxRowHeight = (availableSize.Height) / Row;
                Size MyDesiredSize = new Size();
                int i = 0;
                for (int a = 0; a < Row; a++)
                {
                    double value2 = 0.0;
                    for (int b = 0; b < (Math.Pow(2, a)); b++)
                    {
                        if (i < total)
                        {
                            Children[i].Measure(availableSize);
                            double value1 = Children[i].DesiredSize.Height;
    
                            if (value1 >= value2)
                            {
    
                                MyDesiredSize.Height = value1;
                                value2 = value1;
                            }
                            else
                            {
                                MyDesiredSize.Height = value2;
    
                            }
                            i++;
                        }
                    }
                    MyDesiredSize.Height = MyDesiredSize.Height > MaxRowHeight ? MyDesiredSize.Height : MaxRowHeight;
                }
                               return MyDesiredSize;
            }
        }
