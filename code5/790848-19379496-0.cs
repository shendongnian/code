    private static IPEndPoint _listeningEndPoint = null;
    public FeedbackListener( int feedbackPort )
    {
        if ( _listeningEndPoint == null)
        {
           _listeningEndPoint =  new IPEndPoint( IPAddress.Any, feedbackport);
        }
        else
        {
            _listeningEndPoint.Port = feedbackport;
        } 
    }
