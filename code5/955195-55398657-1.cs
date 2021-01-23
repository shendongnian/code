       public class PreferenceRequest
        {
            [Required]
            public int UserId;
            public bool usePopups;
            public bool useTheme;
            public int recentCount;
            public string[] detailsSections;
        }
