    public ref class TelegramWrapper : public MessageWrapper
    {
        public:
            TelegramWrapper(TelegramWrapper^ tel);
            TelegramWrapper(const &Telegram tel);
        private:
            Telegram *myTelegram;
        property int MyVariablesX {
            public: int get { return myTelegram->someVariablesX; }
            public: void set(int value) { myTelegram->someVariablesX = value; }
        }
        property int MyVariablesY {
            public: int get { return myTelegram->someVariablesY; }
            public: void set(int value) { myTelegram->someVariablesY = value; }
        }
    };
    TelegramWrapper::TelegramWrapper(TelegramWrapper^ tel) : MessageWrapper(tel->Lenght)
    {
        myTelegram = tel->myTelegram;
    }
    TelegramWrapper::TelegramWrapper(const &Telegram tel) : MessageWrapper(tel.lenght)
    {
        myTelegram = tel;
    }
