    public class MyLayoutItem : LayoutItem
    {
        public string SubTitle 
        {
             get { return (string)this.GetValue(SubTitleProperty); }
             set { this.SetValue(SubTitleProperty, value); } 
        }
     
        public static readonly DependencyProperty SubTitleProperty = DependencyProperty.Register("SubTitle", typeof(string), typeof(MyLayoutItem),new PropertyMetadata(string.Empty));
    }
