    public interface IKalmanFilter
    {
        /// <summary>
        /// The current observation vector being used.
        /// </summary>
        Vector<double> Observation { get; }
        /// <summary>
        /// The best estimate of the current state of the system.
        /// </summary>
        Vector<double> State { get; }
        /// <summary>
        /// The covariance of the current state of the filter. Higher covariances
        /// indicate a lower confidence in the state estimate.
        /// </summary>
        Matrix<double> StateVariance { get; }
        /// <summary>
        /// The one-step-ahead forecast error of y given the previous measurement.
        /// </summary>
        Vector<double> ForecastError { get; }
        /// <summary>
        /// The one-step ahead forecast error variance.
        /// </summary>
        Matrix<double> ForecastErrorVariance { get; }
        /// <summary>
        /// The Kalman Gain matrix.
        /// </summary>
        Matrix<double> KalmanGain { get; }
        /// <summary>
        /// Performs a prediction of the next state of the system.
        /// </summary>
        /// <param name="T">The state transition matrix.</param>
        void Predict(Matrix<double> T);
        /// <summary>
        /// Perform a prediction of the next state of the system.
        /// </summary>
        /// <param name="T">The state transition matrix.</param>
        /// <param name="R">The linear equations to describe the effect of the noise
        /// on the system.</param>
        /// <param name="Q">The covariance of the noise acting on the system.</param>
        void Predict(Matrix<double> T, Matrix<double> R, Matrix<double> Q);
        /// <summary>
        /// Updates the state estimate and covariance of the system based on the
        /// given measurement.
        /// </summary>
        /// <param name="y">The measurements of the system.</param>
        /// <param name="T">The state transition matrix.</param>
        /// <param name="Z">Linear equations to describe relationship between
        /// measurements and state variables.</param>
        /// <param name="H">The covariance matrix of the measurements.</param>
        void Update(Vector<double> y, Matrix<double> T, 
            Matrix<double> Z, Matrix<double> H, Matrix<double> Q);
    }
