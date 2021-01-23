    /// <summary>
    /// Represents an object that can load the firmware
    /// </summary>
    public interface ILoadFirmware
    {
        /// <summary>
        /// Loads firmware on a device
        /// </summary>
        bool LoadFirmware();
        event EventHandler Progress;
        event EventHandler Status;
    }
    public class ChipLoadFirmware : ILoadFirmware
    {
        private readonly log4net.ILog logger = Logging.Log4NetManager.GetLogger();
        private readonly ImageLoader imageLoader = new ImageLoader ();
        private bool abort = false;
        private string cmdText = string.Empty;
        private string errortext = string.Empty;
        private string isaIp;
        public event EventHandler Progress;
        public event EventHandler Status;
        /// <summary>
        /// Sets up an ImageLoader
        /// </summary>
        /// <param name="isaTargetIpAddress">The IP address of the ISA to load the firmware on</param>
        public ChipLoadFirmware (string isaTargetIpAddress)
        {
            this.isaIp = isaTargetIpAddress;
            imageLoader.EventHandler += (s, e) => { };
            logger.DebugFormat("Using IP Address {0}", isaTargetIpAddress);
        }
        /// <summary>
        /// Loads the firmware onto the device
        /// </summary>
        /// <returns>Returns true if successful</returns>
        public bool LoadFirmware()
        {
            bool result = imageLoader.Run(this.isaIp,
                false,
                Command.Command,
                string.Empty,
                CommandFlag.CommandFlag,
                2000,
                (p) => { Progress(this, EventArgs.Empty); },
                (s) => { Status(this, EventArgs.Empty); },
                ref this.abort,
                out this.cmdText,
                out this.errortext);
            if (!result)
            {
                result = false;
                throw new InvalidOperationException(
                    string.Format(
                        "ImageLoader failed with message: {0}",
                        errortext));
            }
            return result;
        }
    }
    public class CalibrationManager : ICalibrationManager
    {
        const uint startAddress = 0x00000000;
        const uint startAddress = 0x00000000;
        private readonly log4net.ILog logger;
        private readonly ISignalGenerator sigGenerator;
        public readonly ILoadFirmware loadFirmware;
        private readonly IReader reader;
        private readonly IValueParser valueParser;
        private readonly IRepository<CalibrationValue> calibrationRepository;
        private readonly IRepository<UIDList> uidRepository;
        private string uid;
        public CalibrationManager(ISignalGenerator sigGen, ILoadFirmware loadFirmware, IReader chipRreader, IValueParser chipValueParser, IRepository<UIDList> uidRepo, IRepository<CalibrationValue> calRepo)
        {
            if (sigGen == null ||
                loadFirmware == null ||
                chipReader == null ||
                chipValueParser == null ||
                calRepo == null ||
                uidRepo == null) throw new ArgumentNullException();
            logger = Logging.Log4NetManager.GetLogger();
            this.sigGenerator = sigGen;
            this.loadFirmware = loadFirmware;
            this.reader = chipReader;
            this.valueParser = chipValueParser;
            this.uidRepository = uidRepo;
            this.calibrationRepository = calRepo;
        }
        public void Calibrate(bool reuse)
        {
            int voltageG;
            int currentG;
            // Read uid from device
            this.uid = uidReader.ReadUid();
            logger.DebugFormat("Read UID {0}", this.uid);
            var possibleCalibrations = getCalibrationDataFromRepo();
            if (possibleCalibrations.Any() && reuse)
            {
                logger.Debug("Reusing existing values");
                var existingCalibration = possibleCalibrations.OrderByDescending(c => c.DateCalibrated).First();
                currentG = existingCalibration.CurrentGain;
                voltageG = existingCalibration.VoltageGain;
            }
            else
            {
                logger.Debug("Reading new values");
                // Set voltage and current for signal generator
                sigGenerator.SetOutput(187, 60);
                // Load firmware onto chip for CLI commands
                loadFirmware.LoadFirmware();
                UpdateStateChange(StateOfDevice.LoadFirmware);
                // Read voltage from device and calibrate
                voltageG = valueParser.ReadVoltageValue();
                UpdateStateChange(StateOfDevice.CalibrateVoltage);
                // Read current from device and calibrate
                sigGenerator.SetOutput(38, 60);
                currentG = valueParser.ReadCurrentValue();
                UpdateStateChange(StateOfDevice.CalibrateCurrent);
                // Insert values into table
                CalibrationValue cv = new CalibrationValue();
                cv.UidId = uidRepository.GetBy(e => e.UID.Equals(this.uid)).Id;
                cv.CurrentGain = currentG;
                cv.VoltageGain = voltageG;
                calibrationRepository.Insert(cv);
                calibrationRepository.Submit();
                UpdateStateChange(StateOfDevice.DatabaseInsert);
            }
            logger.DebugFormat("Updated database for current gain to {0} and voltage gain to {1}", currentG, voltageG);
            // Once here, device has passed all phases and device is calibrated
            UpdateStateChange(StateOfDevice.CalibrationComplete);
        }
        private IQueryable<CalibrationValue> getCalibrationDataFromRepo()
        {
            int uidId = uidRepository.GetBy(e => e.UID.Equals(this.uid)).Id;
            return calibrationRepository.SearchFor(c => c.UidId == uidId);
        }
        public bool CalibrationDataExists()
        {
            this.uid = uidReader.ReadUid();
            logger.DebugFormat("Read UID {0}", this.uid);
            return getCalibrationDataFromRepo().Any();
        }
        public event Action<StateOfDevice, string> StateChange;
        private void UpdateStateChange(StateOfDevice state, string message = "")
        {
            var sc = StateChange;
            if (sc != null)
            {
                StateChange(state, message);
            }
        }
    }
    public class Form
    {
        Label labelToModify;
        void MagickButtonClick(object Source, EventArgs e)
        { 
        
            CalibrationManager manager = new CalibrationManager(.......);
    
            manager.loadFirmware.Progress += (o, e) => { labelToModify.Text = "Some progress achieved!!";  };
        
        }
    
    }
