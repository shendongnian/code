    public class BArray : List<B>
    {
        public override void ToString()
        {
            return string.Join(Items.Select(item => item.Name), ", ");
        }
    }
