    public class HoraireChefViewModel
    {
      public ChefModel mChef { get; set; }
      public DateTime mDate { get; set; } // change
      public int mStartHour { get; set; } // change
      public int mEndHour { get; set; } // change
      public HoraireChefViewModel()
      {
        mDate = DateTime.Now;
      }
    }
