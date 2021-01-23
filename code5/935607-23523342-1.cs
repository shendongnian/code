    //What patches are available?
    public class PatchCheckOutcome {
         public PatchCheckOutcome(bool newPatchAvailble, List<Patch> availablePatches) {
              NewPatchAvailable = newPatchAvailable;
              AvailablePatches = availablePatches ?? New List<Patch>();
         }
 
         public bool NewPatchAvailable { get; private set; }
         public List<Patch> AvailablePatches { get; private set; }
    }
    //Information required to check what patches are available
    public class PatchCheckInformation {
    
         public string CurrentVersion { get; set; }
    }
    //API method
    public PatchCheckOutcome GetAvailablePatches(PatchCheckInformation info);
