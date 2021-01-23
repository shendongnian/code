    private void ChangeState()
    {
        switch (_state) {
            case  TrainingState.Stopped:
                //TODO: Initialize and start the timer, display state
                _state = TrainingState.Preparing;
                break;
            case  TrainingState.Preparing:
                //TODO: Adjust timer intervall for working phase, display state
                _roundNo = 1; // We are going into the first round
               _state = TrainingState.Working;
                break;
            case  TrainingState.Working:
                 //TODO: Adjust timer intervall for resting phase, display state
                _state = TrainingState.Resting;
                break;
            case  TrainingState.Resting:
                if (_roundNo == 8) {
                    _state = TrainingState.Stopped;
                    //TODO: stop timer, display state
                } else {
                    //TODO: Adjust timer intervall for working phase, display state
                    _roundNo++; // We are going into the next round
                   _state = TrainingState.Working;
                }
                break;
        }
    }
