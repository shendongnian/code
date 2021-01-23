    Class AgeRangeAndWeight {
       int FromAge {get;set;}
       int ToAge {get;set;}
       double Weight {get;set;}
    }
    Class AgeRangeAndWeight Collection() : List<AgeRangeAndWeight> {
      AgeRangeAndWeight FindByAge(int age) {
        foreach(AgeRangeAndWeight araw in this) {
          if(age >= araw.FromAge && age <= araw.ToAge) {
            return araw;
          }
        }
      return null;
      }
    }
