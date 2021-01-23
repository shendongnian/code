    public class EnhancedBuilder<TModel, TItem, TInvalidModel> : NewBuilder<TModel, TItem>
        where TModel : SomeReportVM<TItem>, new()
        where TItem : ReportItem
        where TInvalidModel : SomeReportVM<TItem>, new() // Made an assumption here.
        // It would likely be wise to create an InvalidVM base class to handle common
        // issues such as roles, and defer the rest to child builders.
    {
        public override ReportVM Build(ReportArgs args)
        {
           /* Some code to get roles here */   
            if( ** validation code fails ** ) 
            {
                return new TInvalidModel
                {
                }
            }
            
            return new TModel
            {
                FeedbackModel = FeedbackBuilder.Build(inputGrid.Report.Id),
            };                       
        }
    }
