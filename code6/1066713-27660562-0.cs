    public UICenterOnChild MyCenterOnChildObject;
    public Transform SomeTransform;
    
    void SetDefaultChild() {
        this.MyCenterOnChildObject.CenterOn(this.SomeTransform);
    }
