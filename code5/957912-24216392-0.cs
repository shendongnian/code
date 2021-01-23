    void Main()
    {
        SomeFunc(2, () => {
            //do stuff
        });
    }
    public void SomeFunc(int inputParam, Action body)
    {
        //do before stuff
        body();
        // do after stuff
    }
