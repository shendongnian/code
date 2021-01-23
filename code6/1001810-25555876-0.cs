        string path = @"C:\Users\AlphaDog\Desktop\Alumni Revised\AlumiTrackingSystem\AlumiTrackingSystem\AlumiTrackingSystem\AlumiTrackingSystem\image\Vince\Tulips.jpg";
        string[] splitPath = path.Split('\\');
        int start = 0;
        foreach (string s in splitPath) {
             if (s == "image")
                 break;
             else
                 start++;
        }
        string virtualPath = "~/";
        for (int i = start; start < splitPath.Length; start++) {
             virtualPath += (i > start ? "/" : "") + splitPath[start];
        }
    
