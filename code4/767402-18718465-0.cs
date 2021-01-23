    public class MyClass
    {
        private Task _task;
        private static async Task FillAssignmentStudentTableFromExtraUsers(int assignmentId, List<JToken> lstOfExtraUser)
        {
            //...
        }
    
        private void GrdReport_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            //"fire and forget" task
            _task = FillAssignmentStudentTableFromExtraUsers(3,listofjtoken);
        }
    
        private void WorkWithData()
        {
            if(_task != null)
                await _task;
    
            //do something
        }
    
    }
