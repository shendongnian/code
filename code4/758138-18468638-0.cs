    public interface IMyInterface
        {
            int Top { get; set;}
            int Left { get; set; }
            int Width { get; set; }
            int Height { get; set; }
        }
    public void TransformObject(object objObject, int LeftPadding, int TopPadding, int WidthChange, int HeightChange)
            {
                if (objObject is IMyInterface)
                {
                    ((IMyInterface)objObject).Top = TopPadding;
                    ((IMyInterface)objObject).Left = LeftPadding;
                    ((IMyInterface)objObject).Width = WidthChange;
                    ((IMyInterface)objObject).Height = HeightChange;
                }
            }
