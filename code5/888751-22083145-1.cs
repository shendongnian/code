Set Model.test to null in your controller or model constructor, and make sure it's nullable. A bool has to be either true or false, null will mean neither is checked.
    public class WhateverTheModelIs
    {
        public bool? test { get; set; }
        public WhateverTheModelIs()
        {
            test = null;
        }
    }
Note: Setting the value to null is redundant as it is the default. I wanted to be explicit for the sake of the example.
