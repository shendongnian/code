     Variable localVariableName;
     public GameObject OwnerOfClassA;
     public void Start() {
         localVariableName = OwnerOfClassA.GetComponent<ClassA>().VariableName; 
     }
    
