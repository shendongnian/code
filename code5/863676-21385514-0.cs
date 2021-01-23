    public int[] shiftRight(int[] arr) 
    {
        int[] demo = new int[arr.length];
        Array.Copy(arr,arr.Length-1,demo,0,1); // Copy last position to first
        Array.Copy(arr,0,demo,1,arr.Length-1); // Copy the rest shifted one       
        return demo;
    }
