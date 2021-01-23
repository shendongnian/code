    private class FaceParser
    {
        public static bool TryParse(string line, out IFace face)
        {
            if (Face3.TryParse(line, out face)) { return true; }
            if (Face4.TryParse(line, out face)) { return true; }
            return false;
        }
    }  
