    private bool IsWithinResidencyRange(DateTime dateFrom, DateTime dateTo, double consecutiveHours){
        if(dateFrom < timeFromResidencyRange){
            return ((dateTo - timeFromResidencyRange).TotalHours > consecutiveHours);
        }else if(dateTo > timeToResidencyRange){
            return ((timeToResidencyRange- dateFrom).TotalHours > consecutiveHours);
        }else{
            //Is completely within range.
            return ((dateTo - dateFrom).TotalHours > consecutiveHours);
        }
    }
    
