          public bool IsSaved
          {
              get
               {
                    if(IsDirty || displayMasterRepository.IsObjectChanged())
                         return false;
                    
                    return IsDeveloper && CheckValidation(null);
                }
          }
