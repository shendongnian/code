        public class AConcreteViewModelEnricher:IModelEnricher<AConcreteViewModel>{
        
        AConcreteViewModelEnricher(Repo1 repo1, Reop2 rep2){
    ........
    }
      
        AConcreteViewModel Enrich(AConcreteViewModel model){
               //Do stuff with repo etc and 
                return model
        }
    }
    
