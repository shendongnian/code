    using System.Windows.Forms;
    using System.IO.Ports;
    
    namespace Milk_Units
    {
        public partial class MainForm : Form
        {
            private Settings _settings;
            private SettingsIniFile _settingsIniFile = new SettingsIniFile();
    
            public MainForm()
            {
                InitializeComponent();
                LoadSettings(false);
                LoadComportName();
            }
    
            private void LoadSettings(bool defaults)
            {
                _settings = _settingsIniFile.LoadSettings(defaults);
                LoadTextBoxes();
            }
    
            private void SaveSettings()
            {
                SaveTextBoxes();
                _settingsIniFile.Save(_settings);
            }
    
            private void LoadTextBoxes()
            {
                //ACR
                _startRemovalTextBox.Text = _settings.AcrStartRemoval;
                _removalTimeTextBox.Text = _settings.AcrRemovalTime;
                _removalDelayTextBox.Text = _settings.AcrRemovalDelay;
                //CLEANING
                _durCleaningTextbox.Text = _settings.CleanDurCleaning;
                _timeValveOnTextbox.Text = _settings.CleanTimeValveOn;
                _timeValveOffTextBox.Text = _settings.CleanTimeValveOff;
                //CALIBRATE
                _contentLeftTextBox.Text = _settings.CalibrateContentLeft;
                _calibrateLeftTextBox.Text = _settings.CalibrateCalibrateLeft;
                _contentRightTextBox.Text = _settings.CalibrateContentRight;
                _calibrateRightTextBox.Text = _settings.CalibrateCalibrateRight;
                //CONDUCTIVITY
                _factorLeftTextBox.Text = _settings.ConductFactorLeft;
                _offsetLeftTextBox.Text = _settings.ConductOffsetleft;
                _factorRightTextBox.Text = _settings.ConductFactorRight;
                _offsetRightTextBox.Text = _settings.ConductOffsetRight;
                _levelLeftTextBox.Text = _settings.ConductLevelLeft;
                _levelRightTextBox.Text = _settings.ConductLevelRight;
                //GENERAL
                _typeOfValveTextBox.Text = _settings.GeneralTypeOfValve;
                _indicatorTextBox.Text = _settings.GeneralIndicator;
                _inverseOutputTextBox.Text = _settings.GeneralInverseOutput;
                _restartTimeTextBox.Text = _settings.GeneralRestartTime;
                _waterTimeTextBox.Text = _settings.GeneralWaterTime;
                _gateDelayTextbox.Text = _settings.GeneralGateDelay;
                //PULSATION
                _pulsationTextBox.Text = _settings.PulsationPulsationPm;
                _ratioFrontTextBox.Text = _settings.PulsationSrRatioFront;
                _ratioBackTextBox.Text = _settings.PulsationSrRatioBack;
                _stimulationTextBox.Text = _settings.PulsationStimulationPm;
                _stimFrontTextBox.Text = _settings.PulsationSrStimFront;
                _stimBackTextBox.Text = _settings.PulsationSrStimBack;
                _stimulationDurTextBox.Text = _settings.PulsationStimulationDur;
                return _settings;
            }
            private void SaveTextBoxes()
            {
                //ACR
                _settings.AcrStartRemoval = _startRemovalTextBox.Text;
                _settings.AcrRemovalTime = removalTimeTextBox.Text; 
                _settings.AcrRemovalDelay = _removalDelayTextBox.Text;
                //CLEANING
                _settings.CleanDurCleaning = _durCleaningTextbox.Text;
                _settings.CleanTimeValveOn = _timeValveOnTextbox.Text;
                _settings.CleanTimeValveOff = _timeValveOffTextBox.Text;
                //CALIBRATE
                _settings.CalibrateContentLeft = _contentLeftTextBox.Text;
                _settings.CalibrateCalibrateLeft = _calibrateLeftTextBox.Text;
                _settings.CalibrateContentRight = _contentRightTextBox.Text;
                _settings.CalibrateCalibrateRight = _calibrateRightTextBox.Text;
                //CONDUCTIVITY
                _settings.ConductFactorLeft = _factorLeftTextBox.Text;
                _settings.ConductOffsetleft = _offsetLeftTextBox.Text;
                _settings.ConductFactorRight = _factorRightTextBox.Text;
                _settings.ConductOffsetRight = _offsetRightTextBox.Text;
                _settings.ConductLevelLeft = _levelLeftTextBox.Text;
                _settings.ConductLevelRight = _levelRightTextBox.Text;
                //GENERAL
                _settings.GeneralTypeOfValve = _typeOfValveTextBox.Text;
                _settings.GeneralIndicator = _indicatorTextBox.Text;
                _settings.GeneralInverseOutput = _inverseOutputTextBox.Text;
                _settings.GeneralRestartTime = _restartTimeTextBox.Text;
                _settings.GeneralWaterTime = _waterTimeTextBox.Text;
                _settings.GeneralGateDelay = _gateDelayTextbox.Text;
                //PULSATION
                _settings.PulsationPulsationPm = _pulsationTextBox.Text;
                _settings.PulsationSrRatioFront = _ratioFrontTextBox.Text;
                _settings.PulsationSrRatioBack = _ratioBackTextBox.Text;
                _settings.PulsationStimulationPm = _stimulationTextBox.Text;
                _settings.PulsationSrStimFront = _stimFrontTextBox.Text;
                _settings.PulsationSrStimBack = _stimBackTextBox.Text;
                _settings.PulsationStimulationDur = _stimulationDurTextBox.Text;
            }
    
            private void DefaultSettingButtonClick(object sender, System.EventArgs e)
            {
                LoadSettings(true);
                SaveSettings();
                LoadComportName();
            }
    
    
            private void SendSettingsButtonClick(object sender, System.EventArgs e)
            {
                SaveSettings();
            }
    
            private void LoadComportName()
            {
                _comPortComboBox.DataSource = SerialPort.GetPortNames();
            }
    
        }
