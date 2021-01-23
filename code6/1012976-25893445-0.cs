    public abstract class BaseVehicle<T> where T : BaseShape
    {
        public void SaveChanges(T shape)
        {
            if (!shape.Modified()) return;
            var errorList = new List<string>();
            shape.Validate(errorList);
            if (errorList.Count > 0)
            {
                var sb = new StringBuilder();
                foreach (string s in errorList)
                {
                    sb.Append(s + Environment.NewLine);
                }
                throw new Exception(sb.ToString());
            }
            WriteToStorage(shape);
            if (!shape.Active)
                MarkInactive(ref shape);
        }
        public abstract void WriteToStorage(T shape);
        public abstract void MarkInactive(ref T shape);
    }
    public class DescendantVehicle : BaseVehicle<DescendantShape>
    {
        public override void WriteToStorage(DescendantShape shape)
        {
            //
        }
        public override void MarkInactive(ref DescendantShape shape)
        {
            shape = null;
        }
    }
