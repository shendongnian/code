    class planner{
        List<Appointment> Appointments = new List<Appointment>();
        void initDay(){
        Datetime baseTime = new Datetime(8,0,0);//8 o'clock
            for(int a = 0; a<8; a++){
                Appointments.Add(new Appointment(new Datetime(H,M,0),new Timespan(1,0,0))); 
                baseTime.Add(new timespan(0,15,0)); //Add 15 minutes
            }
            //Now you have a list of appointents where you can ask for all openings 
            //of all appointments by simply asking
            var UnFilled = Appointments.Where(a=>!a.isFilled());
            var Filled = Appointments.Where(a=>a.isFilled());
        }
    }
    public class Appointment{
        User filled = null;
        Datetime start;
        Timespan time;// Makes for adjustable time span
        public Appointment(Datetime Start, Timespan Time){
             start = Start;
             time = Time;
        }
        public void fillAppointment(User Fill){
            filled = Fill;
        }
        public bool isFilled(){
            return filled != null? true:false;
        }
    }
