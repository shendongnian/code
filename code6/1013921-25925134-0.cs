    private class Video
    {
        public string Name { get; set; }
        public int Preference { get; set; }
    }
    public static void GenericTester()
    {
        // Initialize array with item name and preference
        var videos = new List<Video>
        {
            new Video {Name = "zero", Preference = 0},
            new Video {Name = "one", Preference = 1},
            new Video {Name = "two", Preference = 2},
            new Video {Name = "three", Preference = 3},
            new Video {Name = "four", Preference = 4},
            new Video {Name = "five", Preference = 5},
            new Video {Name = "six", Preference = 6},
            new Video {Name = "seven", Preference = 7},
            new Video {Name = "eight", Preference = 8},
            new Video {Name = "nine", Preference = 9},
            new Video {Name = "ten", Preference = 10}
        };
        // Dictionary to store results of how many times each
        // preference was selected (for testing purposes)
        var results = new Dictionary<int, int>();
        for (int i = 0; i <= videos.Max(v => v.Preference); i++)
        {
            results[i] = 0;  // Init all items to zero
        }
        // Init random number generator
        var rand = new Random();
        // Run this loop many times and gather results for testing
        for (int n = 1; n < 100000; n++)
        {
            // Get a random number between zero and the sum of all the preferences
            var number = rand.Next(0, videos.Sum(v => v.Preference));
            // Initialize index to the highest preference
            var index = videos.Max(v2 => v2.Preference);
            var rollingSumOfWeights = 0;
            // Select an index from the video list, but weighted by preference
            foreach(var video in videos)
            {
                // Add the current item's weight to the rolling sum
                rollingSumOfWeights += video.Preference;
                // If we've hit or passed the random number, select this item
                if (rollingSumOfWeights >= number)
                {
                    index = video.Preference;
                    break;
                }
            }
            results[index]++;
        }
        foreach (var result in results)
        {
            Console.WriteLine("The preference value '{0}' was selected '{1}' times.", result.Key, result.Value);
        }
    }
