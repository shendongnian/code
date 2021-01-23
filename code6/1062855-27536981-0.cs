    class Country { // Apologies that this sketch is more C++ than C#
    public:
       Country(string name_, int power_);
    private:
       string name;
       int power;
    };
    void MakeCountries()
    {
        countries.Add(new Country("USA", 50));
        countries.Add(new Country("Germany", 60));
        // ....
    }
