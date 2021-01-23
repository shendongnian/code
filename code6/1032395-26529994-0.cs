    public class AssignmentHandler<TObj> where TObj : BaseAssignment
    {
        public void Test()
        {
            var assignedItemField = typeof(TObj).GetField("AssignedItem", BindingFlags.Static | BindingFlags.Public);
            Console.WriteLine(assignedItemField .GetRawConstantValue());
        }
    }
