    Public Shared Function getCarByID(CarID As Integer) As Car
            Using db As MyAppContext = New MyAppContext
                Dim car As New Car
                car = db.Cars.Include("Owner").First(Function(x) x.CarID = CarID)
                Return car
            End Using
    End Function
