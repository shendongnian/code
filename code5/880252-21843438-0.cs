    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace TravelHelper_WP8
    {
        public class CustomPanel : Panel
        {
            public CustomPanel()
            {
                /**default 2 columns**/
                ColumnCount = 2;
                columnHeight = new double[ColumnCount];
                this.UseLayoutRounding = true;
            }
    
            static double[] columnHeight;
    
            public int ColumnCount
            {
                get { return (int)this.GetValue(ColumnCountProperty); }
                set { this.SetValue(ColumnCountProperty, value); }
            }
    
            public static DependencyProperty ColumnCountProperty = DependencyProperty.Register("ColumnCount", typeof(int), typeof(CustomPanel), new PropertyMetadata(new PropertyChangedCallback((o, e) =>
            {
                columnHeight = new double[(int)e.NewValue];
                if (o == null || e.NewValue == e.OldValue)
                    return;
                o.SetValue(ColumnCountProperty, e.NewValue);
            })));
    
            protected override Size MeasureOverride(Size availableSize)
            {
                int indexY = this.Children.Count / ColumnCount;
                if (this.Children.Count % ColumnCount > 0) indexY++;
                int flagY = 0;
                Size resultSize = new Size(0, 0);
                #region<---- Measure Value
    
                for (int i = 0; i < indexY; i++)//Column
                {
                    if (i == indexY - 1)
                    {
                        int residual = Children.Count - i * ColumnCount;
                        if (Children.Count <= ColumnCount)
                        {
                            residual = Children.Count;
                        }
    
                        for (int h = 0; h < residual; h++)
                        {
                            Children[ColumnCount * flagY + h].Measure(availableSize);
                            resultSize.Width = (Children[ColumnCount * flagY + h].DesiredSize.Width) * ColumnCount;
                            columnHeight[h] += Children[ColumnCount * flagY + h].DesiredSize.Height;
                        }
                    }
                    else
                    {
                        for (int y = 0; y < ColumnCount; y++)
                        {
                            Children[ColumnCount * flagY + y].Measure(availableSize);
                            resultSize.Width = (Children[ColumnCount * flagY + y].DesiredSize.Width) * ColumnCount;
                            columnHeight[y] += Children[ColumnCount * flagY + y].DesiredSize.Height;
                        }
                        flagY++;
                    }
                }
                #endregion
    
                resultSize.Height = columnHeight.Max();
                return resultSize;
            }
    
            protected override Size ArrangeOverride(Size finalSize)
            {
                for (int i = 0; i < columnHeight.Count(); i++)
                {
                    columnHeight[i] = 0;
                }
                int indexY = this.Children.Count / ColumnCount;
                if (this.Children.Count % ColumnCount > 0) indexY++;
                int flagY = 0;
                double flagX = 0;
    
                #region<------Layout
                for (int i = 0; i < indexY; i++)//Column
                {
                    finalSize.Width = (Children[i].DesiredSize.Width) * ColumnCount;
                    if (i == indexY - 1)
                    {
                        flagX = 0;
                        int residual = Children.Count - i * ColumnCount;
                        if (Children.Count <= ColumnCount)
                        {
                            residual = Children.Count;
                        }
                        for (int h = 0; h < residual; h++)
                        {
                            Children[ColumnCount * i + h].Arrange(new Rect(new Point(flagX, columnHeight[h]), Children[ColumnCount * i + h].DesiredSize));
                            columnHeight[h] += Children[ColumnCount * flagY + h].DesiredSize.Height;
                            flagX += Children[ColumnCount * i + h].DesiredSize.Width;
                        }
                    }
                    else
                    {
                        for (int y = 0; y < ColumnCount; y++)
                        {
                            Children[ColumnCount * flagY + y].Arrange(new Rect(new Point(flagX, columnHeight[y]), Children[ColumnCount * i + y].DesiredSize));
                            columnHeight[y] += Children[ColumnCount * flagY + y].DesiredSize.Height;
                            flagX += Children[ColumnCount * flagY + y].DesiredSize.Width;
                        }
                        flagX = 0; flagY++;
                    }
                }
                #endregion
                return finalSize;
            }
        }
    }
