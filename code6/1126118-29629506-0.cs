    namespace FaceToFaceWebsite.Models
    
        {
            public class UserExerciseViewModel
            {
                public List<RegimeItem> AvailableExercises { get; set; }
                public List<RegimeItem> RequestedExercises { get; set; }
        
                public int[] AvailableSelected { get; set; }
                public int[] RequestedSelected { get; set; }
                public string SavedRequested { get; set; }
        
            }
        }
