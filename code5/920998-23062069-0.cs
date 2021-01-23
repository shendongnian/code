    public class TargetedTriggerActionGotoButton : TargetedTriggerAction<DataGrid>
    {
        protected override void Invoke()
        {
            this.Target.SelectedGridItem = GotoLineNumber - 1;
            this.Target.SelectedGridIndex = GotoLineNumber.GetValueOrDefault() - 1;
        }
        //property used as parameter
        public object Parameter {get;set;}
    }
