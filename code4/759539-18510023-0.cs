    public interface ICommand
    {
        public Object execute();
    }
    public class Command : ICommand
    {
        List<Input> inputs;
        public void setInputs(List<Input> inputs)
        {
            this.inputs = inputs;
        }
        public Object execute()
        {
            // do something
        }
    }
    public class ComplexCommand : ICommand
    {
        ComplexObjects inputs;
        public void setInputs(ComplexObjects inputs)
        {
            this.inputs = inputs;
        }
        public Object execute()
        {
            // do something
        }
    }
