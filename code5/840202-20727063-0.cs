    Namespace BTCE
    #Region "BTCE response classes"
        Public Class Ticker
            Public Property high() As Double
                Get
                    Return m_high
                End Get
                Set(value As Double)
                    m_high = value
                End Set
            End Property
            Private m_high As Double
            Public Property low() As Double
                Get
                    Return m_low
                End Get
                Set(value As Double)
                    m_low = value
                End Set
            End Property
            Private m_low As Double
            Public Property avg() As Double
                Get
                    Return m_avg
                End Get
                Set(value As Double)
                    m_avg = value
                End Set
            End Property
            Private m_avg As Double
            Public Property vol() As Double
                Get
                    Return m_vol
                End Get
                Set(value As Double)
                    m_vol = value
                End Set
            End Property
            Private m_vol As Double
            Public Property vol_cur() As Double
                Get
                    Return m_vol_cur
                End Get
                Set(value As Double)
                    m_vol_cur = value
                End Set
            End Property
            Private m_vol_cur As Double
            Public Property last() As Double
                Get
                    Return m_last
                End Get
                Set(value As Double)
                    m_last = value
                End Set
            End Property
            Private m_last As Double
            Public Property buy() As Double
                Get
                    Return m_buy
                End Get
                Set(value As Double)
                    m_buy = value
                End Set
            End Property
            Private m_buy As Double
            Public Property sell() As Double
                Get
                    Return m_sell
                End Get
                Set(value As Double)
                    m_sell = value
                End Set
            End Property
            Private m_sell As Double
            Public Property updated() As Integer
                Get
                    Return m_updated
                End Get
                Set(value As Integer)
                    m_updated = value
                End Set
            End Property
            Private m_updated As Integer
            Public Property server_time() As Integer
                Get
                    Return m_server_time
                End Get
                Set(value As Integer)
                    m_server_time = value
                End Set
            End Property
            Private m_server_time As Integer
        End Class
    
        Public Class RootObject
            Public Property ticker() As Ticker
                Get
                    Return m_ticker
                End Get
                Set(value As Ticker)
                    m_ticker = value
                End Set
            End Property
            Private m_ticker As Ticker
        End Class
    #End Region
    
    End Namespace
