    class S
    {
     static S *_inst;
     public:
      static S *instance() {if (!_inst) _inst = new S; return _inst;}
    };
