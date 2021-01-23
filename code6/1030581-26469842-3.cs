    public ref struct MySubClass
    {
        String^ username;
    };
    public ref struct MyClass 
    {
    private:
        MySubClass credentials;
    public:
        property String^ username {
            String^ get()
            {
                return credentials.username;
            }
            void set(String^ value)
            {
                credentials.username = value;
            }
        }
    };
