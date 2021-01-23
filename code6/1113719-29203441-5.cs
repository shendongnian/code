    public class PresentationLayer
    {
        public void Test(double start, double end)
        {
            DiaryEvent diaryEvent = new DiaryEvent(new YogaSpaceEventRepository());
            var apptListForDate = DiaryEvent.LoadAllAppointmentsInDateRange(start, end);
        }
    
    }
