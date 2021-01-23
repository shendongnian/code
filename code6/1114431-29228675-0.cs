     public class Customdata
        {
            public int Id { get; set; }
            public int value { get; set; }
        }
        private void setDataInTag(FrameworkElement obj, Customdata objCustomData)
        {
            obj.Tag = objCustomData;
        }
        private Customdata GetValueFromElement(FrameworkElement obj)
        {
            Customdata objCustomData = new Customdata();
            if (obj.Tag!=null && obj.Tag.GetType()==typeof(Customdata))
                objCustomData = (Customdata)obj.Tag;
            return objCustomData;
        }
