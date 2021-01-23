    using SKYPE4COMLib; // Reference to Skype4COM.dll
    using System;
    using System.Runtime.InteropServices;
    public static class Program {
        public static void Main () {
            Skype skype = new Skype();
            Skype.CurrentUserProfile.RichMoodText = "<i>Test</i>";
        }
    }
