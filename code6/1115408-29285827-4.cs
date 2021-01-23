    [Serializable]
    public class MyAspect : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            args.ReturnValue = null;
            args.FlowBehavior = FlowBehavior.Return;
        }
    }
