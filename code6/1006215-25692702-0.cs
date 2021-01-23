    public Database() {
        var conf = new Config();
        chan = conf.Channel.Replace("#","");
        Init();
    }
