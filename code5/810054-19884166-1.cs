    public class ExerciseActivity
    {
        //Hold the name, and the calorie details in here
        String Name {get;set;}
        double lowCalorieUse {get;set;}
        double mediumCalorieUse {get;set;}
        double highCalorieUse {get;set;}
        //Then to calculate it, its pretty easy
        public double CalculateCaloriesBurnt(double mass, double time)
        {
            double calories = 0;
            if (mass < 130)
            {
                calories = lowCalorieUse;
            }
            //the rest is fairly obvious
            //...
            //Multiply by the time
            return calories * time;
        }
