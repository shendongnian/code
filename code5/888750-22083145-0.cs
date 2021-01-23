Set Model.test to null in your controller or model constructor, and make sure it's nullable. A bool has to be either true or false, null will mean neither is checked.
    public class WhateverTheModelIs
    {
        public bool? test { get; set; }
        public WhateverTheModelIs()
        {
            test = null;
        }
    }
